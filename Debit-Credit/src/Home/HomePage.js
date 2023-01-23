import React, { useState, useEffect } from 'react';
import DebitTb from './DebitTb/DebitTb';
import CreditTb from './DebitTb/CreditTb';
import '../Home/HomePage.css';
import Button from '@mui/material/Button';
import swal from 'sweetalert';



export default function HomePage() {

    let [debit, setDebit] = useState('');
    let [credit, setCredit] = useState('');
    let [tba, setTba] = useState([])
    

    let datetime = new Date();


    function debitbtn() {
        tba.map((tbaitem) => {
            if (Number(debit) == '') {
                alert("Input Null Not Allow !");
                return;
            } else if (Number(debit) < 50) {
                alert("The Lowest 50 Taka Can be Taken Out !")
                return;
            } else if (Number(debit) > Number(tbaitem.amountTk)) {
                alert("You don't have enough money in your account !");
                return;
            }
            //------------------


            let adds = tbaitem.amountTk = Number(tbaitem.amountTk) - Number(debit)
            console.log("sfdfgh", adds)
            let itemdc = {
                "amountId": 1,
                "amountTk": `${adds}`
            }
            // call postFuncTion----------------------------------------
            postFunc(itemdc);
        })

        let ddate = (datetime.getFullYear() + "-" + datetime.getMonth() + "-" + datetime.getDate());
        let ddtime = (datetime.getHours() + ":" + datetime.getMinutes())
        let data = {
            "debitTK": `${Number(debit)}`,
            "debitDate": `${ddate}`,
            "debitTime": `${ddtime}`
        }

        console.log(data);


        fetch("http://localhost:9664/api/DebitModelsClasses/typepost", {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then((result) => {

            result.json().then((resp) => {
                console.warn(resp);
            })
        })

    }



    function postFunc(itemdc) {
        console.warn("item", itemdc)
        fetch(`http://localhost:9664/api/AmountTkClasses/1`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(itemdc)
        }).then((result) => {
            result.json().then((resp) => {
                console.warn(resp)
                //getUsers()
            })
        })
        swal("The transaction has been completed!", "click OK!", "success");



    }




    //--------------------------Credit Button---------------------------------------------------------
    function creditbtn() {
        if (Number(credit) == '') {
            alert("Input Null Not Allow !");
            return;
        } else if (Number(credit) < 50) {
            alert("The Lowest 50 Taka Can be Taken Out !");
            return;
        }



        //------------------
        tba.map((tbaitem) => {

            let adds = tbaitem.amountTk = Number(tbaitem.amountTk) + Number(credit)
            console.log("sfdfgh", adds)
            let itemdc = {
                "amountId": 1,
                "amountTk": `${adds}`
            }
            // call postFuncTion----------------------------------------
            postFunc(itemdc);
            //------------------------
        })

        let cdate = (datetime.getFullYear() + "-" + datetime.getMonth() + "-" + datetime.getDate());
        let cdtime = (datetime.getHours() + ":" + datetime.getMinutes())
        let data = {
            "creditTK": `${Number(credit)}`,
            "creditDate": `${cdate}`,
            "creditTime": `${cdtime}`
        }

        console.log(data);

        fetch("http://localhost:9664/api/CreditModelsClasses/Cpost", {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then((result) => {

            result.json().then((resp) => {
                console.warn(resp);
            })
        })


    }



    //let [allamount,setAllamount]=useState('')

    const [adata, setAData] = useState([]);
    useEffect(() => {
        fetch("http://localhost:9664/api/AmountTkClasses/AAll")
            .then((result) => {
                result.json().then((resp) => {
                    console.log(resp);
                    setAData(resp);
                    setTba(resp);
                })
            });
    }, []);



    //console.log("allamound",allamount);



    return (
        <div>
            <div>
                <div>
                    <h1 className='title'>Debit Or Credit System</h1>
                    <div>

                        <Button onClick={() => (debitbtn())} type='button' variant="contained" size="small">Debit</Button>
                        <input type="number" className='dinput' placeholder='$ Debit Amount'
                            value={debit}
                            onChange={(e) => { setDebit(e.target.value) }} />
                        <input type="number" className='cinput' placeholder='$ Credit Amount'
                            value={credit}
                            onChange={(e) => { setCredit(e.target.value) }} />

                        <Button onClick={creditbtn} type='submit' variant="contained" size="small">Credit</Button>
                    </div><br></br>
                    <div className='DAountcssall'>
                        <div className='DAountcssalls'>
                            {
                                adata.map((aitem, index) =>

                                    <span key={index}>
                                        <p className='DAountcss'>{aitem.amountTk}</p>
                                    </span>
                                )

                            }
                        </div>
                    </div>





                </div>
            </div>
            <div className='TableAll'>
                <div className='TableTow'>
                    <div className='debit'><DebitTb /></div>
                    <div className='aitem'>
                        <h2>Amount</h2>
                        <table border="1">
                            <thead>
                                <tr>
                                    {/* <td>No</td> */}
                                    <td>Amount</td>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    adata.map((aitem, index) =>

                                        <tr key={index}>
                                            {/* <td>{aitem.amountId}</td> */}
                                            <td>{aitem.amountTk}</td>

                                        </tr>
                                    )
                                }</tbody>
                        </table>
                    </div>
                    <div className='credit'><CreditTb /></div>
                </div>
            </div>
        </div>
    );
}
