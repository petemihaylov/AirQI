import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

interface IProps {
  classes: any;
  fontIcon: any;
  title: string;
  reference: string;
  animation: string;
}

export const Item = ({ title, reference, fontIcon, classes, animation }: IProps) => {
  return (
    <li className={classes.navItem}>
      <a href={reference} className={classes.navLink}>
        <div className={classes.fontIcon + " " + animation}>
          <FontAwesomeIcon
            className={""}
            icon={fontIcon}
          />
        </div>
        <span className={classes.linkText}>{title}</span>
      </a>
    </li>
  );
};
