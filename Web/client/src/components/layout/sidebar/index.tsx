import React, ***REMOVED*** useState, useEffect***REMOVED*** from "react";
import ***REMOVED*** createUseStyles***REMOVED*** from "react-jss";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** Item***REMOVED*** from "./item";
import "./global.css";

import ***REMOVED***
  faTools,
  faBell,
  faMapMarked,
  faUserShield,
  faChevronRight,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** fetchNotifications***REMOVED*** from "../../../actions/notificationActions";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";

const Sidebar = (props: any) => ***REMOVED***
  const classes = useStyles();
  const ***REMOVED*** user***REMOVED*** = props;
  const [adminBoard, showAdminBoard] = useState(false);

  /* Gets notifications from DB */
  useEffect(() => ***REMOVED***
    props.dispatch(fetchNotifications());
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    showAdminBoard(user && user.userRole === "Admin");
 ***REMOVED***, []);

  return (
    <div>
      ***REMOVED***user ? (
        <nav className=***REMOVED***classes.navbar***REMOVED***>
          <ul className=***REMOVED***classes.navList***REMOVED***>
            <li className=***REMOVED***classes.logo***REMOVED***>
              <a href="#" className=***REMOVED***classes.navLink***REMOVED***>
                <span className=***REMOVED***classes.brand***REMOVED***>AirQI</span>
                <div className=***REMOVED***classes.fontIcon***REMOVED***>
                  <FontAwesomeIcon icon=***REMOVED***faChevronRight***REMOVED*** />
                </div>
              </a>
            </li>

            <Item
              title=***REMOVED***"Profile"***REMOVED***
              reference=***REMOVED***"/profile"***REMOVED***
              fontIcon=***REMOVED***faTools***REMOVED***
              classes=***REMOVED***classes***REMOVED***
              animation=***REMOVED***""***REMOVED***
            />

            <li className=***REMOVED***classes.navItem***REMOVED***>
              <a href=***REMOVED***"/notifications"***REMOVED*** className=***REMOVED***classes.navLink***REMOVED***>
                ***REMOVED***props.items.length != 0 ? (
                  <div className=***REMOVED***classes.fontIcon + " " + "blob"***REMOVED***>
                    <FontAwesomeIcon className=***REMOVED***""***REMOVED*** icon=***REMOVED***faBell***REMOVED*** />
                    <span className=***REMOVED***classes.notificationItem***REMOVED***>
                      ***REMOVED***props.items.length***REMOVED***
                    </span>
                  </div>
                ) : (
                  <div className=***REMOVED***classes.fontIcon***REMOVED***>
                    <FontAwesomeIcon className=***REMOVED***""***REMOVED*** icon=***REMOVED***faBell***REMOVED*** />
                  </div>
                )***REMOVED***
                <span className=***REMOVED***classes.linkText***REMOVED***>***REMOVED***"Notifications"***REMOVED***</span>
              </a>
            </li>

            <Item
              title=***REMOVED***"Dashboard"***REMOVED***
              reference=***REMOVED***"/dashboard"***REMOVED***
              fontIcon=***REMOVED***faMapMarked***REMOVED***
              classes=***REMOVED***classes***REMOVED***
              animation=***REMOVED***""***REMOVED***
            />
            ***REMOVED***adminBoard && (
              <Item
                title=***REMOVED***"Admin"***REMOVED***
                reference=***REMOVED***"/admin"***REMOVED***
                fontIcon=***REMOVED***faUserShield***REMOVED***
                classes=***REMOVED***classes***REMOVED***
                animation=***REMOVED***""***REMOVED***
              />
            )***REMOVED***
            <li className=***REMOVED***classes.navItem***REMOVED***></li>
          </ul>
        </nav>
      ) : (
        " "
      )***REMOVED***
    </div>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = state.auth;
  const ***REMOVED*** items***REMOVED*** = state.notifications;
  return ***REMOVED***
    user,
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Sidebar);

/* Custom sidebar style */

const useStyles = createUseStyles(***REMOVED***
  navbar: ***REMOVED***
    position: "fixed",
    zIndex: 2,
    transition: "width 100ms ease",
    backgroundColor: "var(--bg-primary)",
 ***REMOVED***,
  navList: ***REMOVED***
    listStyle: "none",
    padding: 0,
    margin: 0,
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    height: "100%",
 ***REMOVED***,
  linkText: ***REMOVED***
    display: "none",
    width: "300px",
    marginLeft: "1rem",
 ***REMOVED***,
  brand: ***REMOVED***
    composes: ["$logoText", "$linkText"],
 ***REMOVED***,
  fontIcon: ***REMOVED***
    fontSize: "1.1rem",
    width: "40px",
    height: "40px",
    minWidth: "40px",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
 ***REMOVED***,
  logo: ***REMOVED***
    textTransform: "uppercase",
    marginBottom: "1rem",
    color: "var(--text-secondary)",
    background: "var(--bg-secondary)",
    fontSize: "1.2rem",
    letterSpacing: "0.3ch",
    width: "100%",
    "& $fontIcon": ***REMOVED***
      transform: "rotate(0deg)",
   ***REMOVED***,
 ***REMOVED***,
  logoText: ***REMOVED***
    display: "inline",
    position: "absolute",
    left: "-400px",
 ***REMOVED***,
  notificationItem: ***REMOVED***
    position: "absolute",
    borderRadius: "50%",
    display: "flex",
    padding: "1px",
    textAlign: "center",
    top: "-2px",
    right: "-3px",
    fontSize: "13px",
    justifyContent: "center",
    color: "white",
    width: "20px",
    height: "20px",
    background: "#f46f",
 ***REMOVED***,
  navItem: ***REMOVED***
    width: "100%",
    "&:last-child": ***REMOVED***
      marginTop: "auto",
   ***REMOVED***,
 ***REMOVED***,
  navLink: ***REMOVED***
    display: "flex",
    alignItems: "center",
    height: "5rem",
    color: "var(--text-primary)",
    textDecoration: "none",
    filter: "grayscale(100%) opacity(0.7)",
    "& $fontIcon": ***REMOVED***
      width: "40px",
      minWidth: "40px",
      margin: "1.2rem",
      display: "flex",
      alignItems: "center",
      justifyContent: "center",
      transition: "200ms",
   ***REMOVED***,
    "&:hover": ***REMOVED***
      textDecoration: "none",
      filter: "grayscale(0%) opacity(1)",
      color: "var(--text-secondary)",
      background: "var(--bg-hover)",
   ***REMOVED***,
 ***REMOVED***,

  [`@media only screen and (min-width: 600px)`]: ***REMOVED***
    navbar: ***REMOVED***
      top: 0,
      width: "5rem",
      height: "100vh",
      "&:hover": ***REMOVED***
        width: "16rem",
     ***REMOVED***,
      "&:hover $fontIcon": ***REMOVED***
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
     ***REMOVED***,
      "&:hover $linkText": ***REMOVED***
        transition: "400ms ease",
        display: "inline",
     ***REMOVED***,
      "&:hover $logo $fontIcon": ***REMOVED***
        transform: "rotate(-180deg)",
        marginLeft: "11rem",
     ***REMOVED***,
      "&:hover $logoText": ***REMOVED***
        left: "1.3rem",
     ***REMOVED***,
   ***REMOVED***,
 ***REMOVED***,
***REMOVED***);
