import React, { Component } from 'react';

const TableHeader = () => { 
    return (
        <thead>
            <tr>
                <th>Start</th>
                <th>End</th>
                <th>Description</th>
            </tr>
        </thead>
    );
}

const TableBody = props => { 
    const rows = props.eventData.map((row, index) => {
        return (
            <tr key={index}>
                <td>{row.startDate}</td>
                <td>{row.endDate}</td>
                <td>{row.description}</td>
            </tr>
        );
    });

    return <tbody>{rows}</tbody>;
}

class Table extends Component {
    render() {
        const { eventData} = this.props;

        return (
            <table>
                <TableHeader />
                <TableBody characterData={eventData}/>
            </table>
        );
    }
}

export default Table;
