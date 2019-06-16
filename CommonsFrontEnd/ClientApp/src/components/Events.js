import React, { Component } from 'react';
import { getWeekNumber, getDateOfISOWeek, getNextDayOfWeek } from './DateFunctions';

export class Events extends Component {
  displayName = Events.name

  constructor(props) {
    super(props);
      this.state = { events: [], event: false, members: ["test"], loading: true, week: getWeekNumber(new Date())};

    fetch('https://localhost:5001/api/events')
      .then(response => response.json())
        .then(response => this.setState({ events: response, loading: false }))
    }

    weekChange = event => {
        const { value } = event.target;
        this.setState({ events: [], loading: true, week: value });
        var newWeek = value.split("-W");
        var from = getDateOfISOWeek(newWeek[1], newWeek[0]);
        var to = getNextDayOfWeek(from, 7);
        fetch("https://localhost:5001/api/events/" + from + "/" + to)
            .then(response => response.json())
            .then(data => this.setState({ events: data, loading: false }))
    }

    openEvent = (index) => {
        let event = this.state.events[index];
        this.setState({ event: event, loading: true });
        this.setMembers(event.memberList.memberList);
    }

    closeEvent = () => {
        this.setState({ event: false });
    }

    setMembers(members) {
        this.state.members = [];
        if (members.length > 0) {
            members.map((member, index) => {
                fetch("https://localhost:5001/api/members/" + member.id)
                    .then(response => response.json())
                    .then(data => {
                        if (members.length === index + 1) {
                            this.setState({
                                members: [...this.state.members, data],
                                loading: false
                            });
                        } else {
                            this.setState({
                                members: [...this.state.members, data]
                            });
                        }
                    })
            })
        } else {
            this.setState({loading:false})
        }
    }

    static renderEventsTable(events, weekChange, week, openEvent) {
      return (   
      <div>
      <input type="week" name="week" value={week} onChange={weekChange}/>
      <table className='table'>
        <thead>
          <tr>
            <th>Start</th>
            <th>End</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
              {events.map((event, index) =>
              <tr style={{cursor:"pointer"}} id={index} key={index} onClick={() => openEvent(index)}>
              <td>{event.startDate.replace("T00:00:00","")} {event.startTime}</td>
              <td>{event.endDate.replace("T00:00:00","")} {event.endTime}</td>
              <td>{event.description}</td>
            </tr>
          )}
        </tbody>
       </table>
       </div>
    );
    }

    static renderEvent(event, members, closeEvent) {
        return (   
            <div>
                <span style={{ fontSize: 30 + "px", cursor: "pointer" }} className="glyphicon glyphicon-arrow-left" onClick={closeEvent}></span>
                <h3 style={{ marginLeft: 10 + "px", display: "inline-block"}}>{event.description}</h3>
                <div style={{ paddingLeft: 40+"px" }}>
                    <h5>{event.startDate.replace("T00:00:00", "")} {event.startTime} to {event.endDate.replace("T00:00:00", "")} {event.endTime}</h5>
                    <p>Category: {event.category}</p>
                    <label>Members: </label>
                    <ul>
                        {members.map((member, index) =>
                            <li key={index}>{member.fullTitle} ({member.party}) - {member.memberFrom}</li>
                        )}
                    </ul>
                </div>
            </div>
        );
    }

    render() {
        var contents;
        if (this.state.loading) {
            contents = <p><em>Loading...</em></p>
        } else {
            if (this.state.event) {
                contents = Events.renderEvent(this.state.event, this.state.members, this.closeEvent);
            } else {
                contents = Events.renderEventsTable(this.state.events, this.weekChange, this.state.week, this.openEvent);
            }
        }

    return (
      <div>
        <h1>Commons - Main Chamber</h1>
        {contents}
      </div>
    );
  }
}
