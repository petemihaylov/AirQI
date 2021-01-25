import React, { useEffect } from "react";

import * as legend from "./js/legend";
import "./css/style.css";

export const Legend = (props: any) => {
  useEffect(() => {
    legend.illustation();
  }, []);

  return (
    <div className="mr-4 fixed-bottom">
        <div className="row flex-row-reverse">
          <div className="card-legend align-self-center">
            <div className="card-body-legend">
              <div id="legend">
                <h5 className="card-title text-center">Health Risk</h5>
                <div className="scale">
                  <div id="gradient-bar"></div>
                  <div className="indicator">Very High</div>
                  <div className="indicator">High</div>
                  <div className="indicator">Medium</div>
                  <div className="indicator">Low</div>
                  <div className="indicator">Very Low</div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
  );
};
