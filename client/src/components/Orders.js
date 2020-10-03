import React from "react";
import Link from "@material-ui/core/Link";
import ***REMOVED*** makeStyles***REMOVED*** from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Title from "./Title";

// Generate Order Data
function createData(id, date, name, shipTo, paymentMethod, amount) ***REMOVED***
  return ***REMOVED*** id, date, name, shipTo, paymentMethod, amount***REMOVED***;
***REMOVED***

const rows = [
  createData(
    0,
    "16 Mar, 2019",
    "Elvis Presley",
    "Tupelo, MS",
    "VISA ⠀•••• 3719",
    312.44
  ),
  createData(
    1,
    "16 Mar, 2019",
    "Paul McCartney",
    "London, UK",
    "VISA ⠀•••• 2574",
    866.99
  ),
  createData(
    2,
    "16 Mar, 2019",
    "Tom Scholz",
    "Boston, MA",
    "MC ⠀•••• 1253",
    100.81
  ),
  createData(
    3,
    "16 Mar, 2019",
    "Michael Jackson",
    "Gary, IN",
    "AMEX ⠀•••• 2000",
    654.39
  ),
  createData(
    4,
    "15 Mar, 2019",
    "Bruce Springsteen",
    "Long Branch, NJ",
    "VISA ⠀•••• 5919",
    212.79
  ),
];

function preventDefault(event) ***REMOVED***
  event.preventDefault();
***REMOVED***

const useStyles = makeStyles((theme) => (***REMOVED***
  seeMore: ***REMOVED***
    marginTop: theme.spacing(3),
 ***REMOVED***,
***REMOVED***));

export default function Orders() ***REMOVED***
  const classes = useStyles();
  return (
    <React.Fragment>
      <Title>Recent Orders</Title>
      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Date</TableCell>
            <TableCell>Name</TableCell>
            <TableCell>Ship To</TableCell>
            <TableCell>Payment Method</TableCell>
            <TableCell align="right">Sale Amount</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          ***REMOVED***rows.map((row) => (
            <TableRow key=***REMOVED***row.id***REMOVED***>
              <TableCell>***REMOVED***row.date***REMOVED***</TableCell>
              <TableCell>***REMOVED***row.name***REMOVED***</TableCell>
              <TableCell>***REMOVED***row.shipTo***REMOVED***</TableCell>
              <TableCell>***REMOVED***row.paymentMethod***REMOVED***</TableCell>
              <TableCell align="right">***REMOVED***row.amount***REMOVED***</TableCell>
            </TableRow>
          ))***REMOVED***
        </TableBody>
      </Table>
      <div className=***REMOVED***classes.seeMore***REMOVED***>
        <Link color="primary" href="#" onClick=***REMOVED***preventDefault***REMOVED***>
          See more orders
        </Link>
      </div>
    </React.Fragment>
  );
***REMOVED***
