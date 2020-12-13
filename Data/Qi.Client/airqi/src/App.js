import { BrowserRouter as Router, Route } from 'react-router-dom';

import Dashboard from './components/Dashboard';

function App() {
  return (
    <Router>
        <Dashboard />
        <Route exact path={'/'} component={Dashboard}/> 

    </Router>
  );
}

export default App;
