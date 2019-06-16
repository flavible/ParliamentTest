
import React, { Component } from 'react';
import Table from './Table';
import Week from './Week';

class App extends Component {
    state = {
        characters: []
    };

    removeCharacter = index => {
        const { characters } = this.state;
    
        this.setState({
            characters: characters.filter((character, i) => { 
                return i !== index;
            })
        });
    }

    handleSubmit = character => {
        this.setState({characters: [...this.state.characters, character]});
    }

    render() {
        const { characters } = this.state;
        
        return (
            <div className="container">
                <h1>React Tutorial</h1>
                <p>Add a character with a name and a job to the table.</p>
                <Table
                    eventData={events}
                />
                <h3>Add New</h3>
                <Week handleSubmit={this.handleSubmit} />
            </div>
        );
    }
}

export default App;