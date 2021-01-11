import ***REMOVED*** IUser***REMOVED*** from "./IUser";

export default class User implements IUser ***REMOVED***
  id: number | undefined;
  username: string | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  password: string | undefined;
  lastActive: Date | undefined;
  isActive: boolean | undefined;
  userRole: string | undefined;

  constructor();
  constructor(
    _username: string,
    _firstName: string,
    _lastName: string,
    _lastActive: Date,
    _isActive: boolean,
    _password: string,
    _userRole: string
  );
  constructor(
    _username?: string,
    _firstName?: string,
    _lastName?: string,
    _lastActive?: Date,
    _isActive?: boolean,
    _password?: string,
    _userRole?: string
  ) ***REMOVED***
    this.username = _username;
    this.firstName = _firstName;
    this.lastName = _lastName;
    this.lastActive = _lastActive;
    this.isActive = _isActive;
    this.password = _password;
    this.userRole = _userRole;
 ***REMOVED***
***REMOVED***
