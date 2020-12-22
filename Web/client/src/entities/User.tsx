import ***REMOVED*** IUser***REMOVED*** from "./IUser";

export default class User implements IUser ***REMOVED***
  id: number | undefined;
  username: string | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  password: string | undefined;
  userRole: string | undefined;

  constructor();
  constructor(
    _username: string,
    _firstName: string,
    _lastname: string,
    _password: string,
    _userRole: string
  );
  constructor(
    _username?: string,
    _firstName?: string,
    _lastname?: string,
    _password?: string,
    _userRole?: string
  ) ***REMOVED***
    this.username = _username;
    this.firstName = _firstName;
    this.lastName = _lastname;
    this.password = _password;
    this.userRole = _userRole;
 ***REMOVED***
***REMOVED***
