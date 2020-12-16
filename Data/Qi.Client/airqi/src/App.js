import { BrowserRouter as Router, Route } from 'react-router-dom';

import Dashboard from './components/Dashboard';
import Map from './components/Map';

function App() {
  return (
    <Router>
      
      <Route exact path={'/'} component={Dashboard} /> 
      <Route exact path={'/map'} component={Map}/> 

    </Router>
  );
}

export default App;
