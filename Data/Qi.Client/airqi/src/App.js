import ***REMOVED*** BrowserRouter as Router, Route***REMOVED*** from 'react-router-dom';

import Dashboard from './components/Dashboard';
import Map from './components/Map';

function App() ***REMOVED***
  return (
    <Router>
      
      <Route exact path=***REMOVED***'/'***REMOVED*** component=***REMOVED***Dashboard***REMOVED*** />
      <Route exact path=***REMOVED***'/map'***REMOVED*** component=***REMOVED***Map***REMOVED*** /> 
      
    </Router>
  );
***REMOVED***

export default App;
