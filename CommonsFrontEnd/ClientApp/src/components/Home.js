import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
            <h1>Welcome to Parliament Events!</h1>
            <p>A Single Page application, built with expansion in mind, created using</p>
        <ul>
          <li>ASP.NET Core and C# (MVC) for cross-platform server-side code</li>
          <li>React for client-side code</li>
          <li>Bootstrap for layout and styling</li>
        </ul>
      </div>
    );
  }
}
