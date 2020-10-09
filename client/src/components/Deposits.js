import React from "react";
import Link from "@material-ui/core/Link";
import ***REMOVED*** makeStyles***REMOVED*** from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Title from "./Title";

function preventDefault(event) ***REMOVED***
  event.preventDefault();
***REMOVED***

const useStyles = makeStyles(***REMOVED***
  depositContext: ***REMOVED***
    flex: 1,
 ***REMOVED***,
***REMOVED***);

export default function Deposits() ***REMOVED***
  const classes = useStyles();
  return (
    <React.Fragment>
      <Title>Recent Deposits</Title>
      <Typography component="p" variant="h4">
        $3,024.00
      </Typography>
      <Typography color="textSecondary" className=***REMOVED***classes.depositContext***REMOVED***>
        on 15 March, 2019
      </Typography>
      <div>
        <Link color="primary" href="#" onClick=***REMOVED***preventDefault***REMOVED***>
          View balance
        </Link>
      </div>
    </React.Fragment>
  );
***REMOVED***
