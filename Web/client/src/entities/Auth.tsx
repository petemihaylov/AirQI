export default class Auth {
  id: number | undefined;
  username: string | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  password: string | undefined;
  lastActive: Date | undefined;
  isActive: boolean | undefined;
  userRole: string | undefined;
  accessToken: string | undefined;

  constructor();
  constructor(
    _id: number,
    _username: string,
    _firstName: string,
    _lastName: string,
    _lastActive: Date,
    _isActive: boolean,
    _password: string,
    _userRole: string,
    _accessToken: string
  );
  constructor(
    _id?: number,
    _username?: string,
    _firstName?: string,
    _lastName?: string,
    _lastActive?: Date,
    _isActive?: boolean,
    _password?: string,
    _userRole?: string,
    _accessToken?: string
  ) {
    this.id = _id;
    this.username = _username;
    this.firstName = _firstName;
    this.lastName = _lastName;
    this.lastActive = _lastActive;
    this.isActive = _isActive;
    this.password = _password;
    this.userRole = _userRole;
    this.accessToken = _accessToken;
  }
}
