import React, {Component} from 'react';

class Week extends Component {
    constructor(props) {
        super(props);
        
        this.initialState = {
            week: getWeekNumber(new Date())
        };

        this.state = this.initialState;
    }

    handleChange = event => {
        const { name, value } = event.target;

        this.setState({
            [name] : value
        });
    }

    render() {
        const { name, job } = this.state; 

        return (
            <input type="week" name="week" value={week} onChange={this.handleChange} />
        );
    }
}

export default Form;