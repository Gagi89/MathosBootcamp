// import logo from './logo.svg';
import './App.css';
import Welcome from './Welcome.js';
import Operator from './Operator.js';

// let operator = new Operator();

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Welcome />
        <img src="https://cdn2.personligalmanacka.se/planner/planner_usp_3.jpg" className="App-logo" alt="logo" />
        <Operator />
        {/* operator.FunOperator(); */}
      </header>
    </div>
  );
}

export default App;
