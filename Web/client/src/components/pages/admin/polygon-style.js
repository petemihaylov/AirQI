import React from "react";
import ***REMOVED*** RENDER_STATE***REMOVED*** from "react-map-gl-draw";


export function customFeatureStyle(***REMOVED***feature, state***REMOVED***)***REMOVED***
     switch (state) ***REMOVED***
       case RENDER_STATE.SELECTED:
       case RENDER_STATE.HOVERED:
       case RENDER_STATE.UNCOMMITTED:
       case RENDER_STATE.CLOSING:
         return ***REMOVED***
           stroke: "rgb(251, 176, 59)",
           strokeWidth: 2,
           fill: "rgb(251, 176, 59)",
           fillOpacity: 0.3,
           strokeDasharray: "4,2",
        ***REMOVED***;

       default:
         return ***REMOVED***
           stroke: "rgb(60, 178, 208)",
           strokeWidth: 2,
           fill: "rgb(60, 178, 208)",
           fillOpacity: 0.1,
        ***REMOVED***;
    ***REMOVED***
***REMOVED*** 

export function customHandleStyle(***REMOVED***feature, state***REMOVED***)***REMOVED***
    switch (state) ***REMOVED***
      case RENDER_STATE.SELECTED:
      case RENDER_STATE.HOVERED:
      case RENDER_STATE.UNCOMMITTED:
        return ***REMOVED***
          fill: "rgb(251, 176, 59)",
          fillOpacity: 0.2,
          stroke: "rgb(255, 255, 255)",
          strokeWidth: 2,
          r: 7,
       ***REMOVED***;

      default:
        return ***REMOVED***
          fill: "rgb(251, 176, 59)",
          fillOpacity: 1,
          stroke: "rgb(255, 255, 255)",
          strokeWidth: 2,
          r: 5,
       ***REMOVED***;
   ***REMOVED***
***REMOVED***