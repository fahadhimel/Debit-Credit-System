import React, { useEffect, useState } from 'react';
import '../DebitTb/decredit.css';




export default function CreditTb() {

    const [data, setData] = useState([]);
    useEffect(() => {
        fetch("http://localhost:9664/api/CreditModelsClasses/Alll")
            .then((result) => {
                result.json().then((resp) => {
                    console.log(resp);
                    setData(resp);
                })
            });
    }, []);


    return (
        <div>
            <h2>Credit Table</h2>
            <div>
                <table border="1" className='ctable'>
                    <thead>
                        <tr>
                            <th>No</th>
                            <th>C-Amount</th>
                            <th>Date</th>
                            <th>Time</th>


                        </tr>
                    </thead>
                    <tbody>
                        {
                            data.map((item, index) =>
                                <tr key={index}>
                                    <td>{item.creditID}</td>
                                    <td>{item.creditTK}</td>
                                    <td>{item.creditDate}</td>
                                    <td>{item.creditTime}</td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>

            </div>
        </div>
    );
}
