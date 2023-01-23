import React, { useEffect, useState } from 'react';

export default function DebitTb() {


    const [data, setData] = useState([]);
    useEffect(() => {
        fetch("http://localhost:9664/api/DebitModelsClasses/All")
            .then((result) => {
                result.json().then((resp) => {
                    console.log(resp);
                    setData(resp);
                })
            });
    }, []);


    return (
        <div>
            <h2>Debit Title</h2>
            <div>
                <table border="1" className='dtable'>
                    <thead>
                        <tr>
                            <th>No</th>
                            <th>D-Amount</th>
                            <th>Date</th>
                            <th>Time</th>


                        </tr>
                    </thead>
                    <tbody>
                        {
                            data.map((item, index) =>
                                <tr key={index}>
                                    <td>{item.debitID}</td>
                                    <td>{item.debitTK}</td>
                                    <td>{item.debitDate}</td>
                                    <td>{item.debitTime}</td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>

            </div>
        </div>
    );
}
