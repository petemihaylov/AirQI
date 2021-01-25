import React, { useEffect } from "react";

import * as bubble from "./js/bubble-animation";
import "./css/style.css";

export const BubbleButton = (props: any) => {
  useEffect(() => {
    bubble.animation();
  }, []);

  return (
    <div>
      <svg xmlns="http://www.w3.org/2000/svg" version="1.1" className="goo">
        <defs>
          <filter id="goo">
            <feGaussianBlur
              in="SourceGraphic"
              stdDeviation="10"
              result="blur"
            />
            <feColorMatrix
              in="blur"
              mode="matrix"
              values="1 0 0 0 0  0 1 0 0 0  0 0 1 0 0  0 0 0 19 -9"
              result="goo"
            />
            <feComposite in="SourceGraphic" in2="goo" />
          </filter>
        </defs>
      </svg>

      <span className="button--bubble__container">
        <input
          className="button button--bubble"
          type="submit"
          value={props.name}
        />

        <span className="button--bubble__effect-container">
          <span className="circle top-left"></span>
          <span className="circle top-left"></span>
          <span className="circle top-left"></span>

          <span className="button effect-button"></span>

          <span className="circle bottom-right"></span>
          <span className="circle bottom-right"></span>
          <span className="circle bottom-right"></span>
        </span>
      </span>
    </div>
  );
};
