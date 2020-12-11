import React from "react";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";

interface IProps ***REMOVED***
  classes: any;
  fontIcon: any;
  title: string;
  reference: string;
  animation: string;
***REMOVED***

export const Item = (***REMOVED*** title, reference, fontIcon, classes, animation***REMOVED***: IProps) => ***REMOVED***
  return (
    <li className=***REMOVED***classes.navItem***REMOVED***>
      <a href=***REMOVED***reference***REMOVED*** className=***REMOVED***classes.navLink***REMOVED***>
        <div className=***REMOVED***classes.fontIcon + " " + animation***REMOVED***>
          <FontAwesomeIcon
            className=***REMOVED***""***REMOVED***
            icon=***REMOVED***fontIcon***REMOVED***
          />
        </div>
        <span className=***REMOVED***classes.linkText***REMOVED***>***REMOVED***title***REMOVED***</span>
      </a>
    </li>
  );
***REMOVED***;
