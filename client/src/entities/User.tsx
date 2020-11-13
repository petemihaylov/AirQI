import { IUser } from "./IUser";

export default class User implements IUser {
  name: any;

  id: number | undefined;
  username: string | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  password: string | undefined;
  userRole: string | undefined;
  status: boolean | undefined;

  constructor();
  constructor(
    _username: string,
    _firstName: string,
    _lastname: string,
    _password: string,
    _userRole: string,
    _status: boolean
  );
  constructor(
    _username?: string,
    _firstName?: string,
    _lastname?: string,
    _password?: string,
    _userRole?: string,
    _status?: boolean
  ) {
    this.username = _username;
    this.firstName = _firstName;
    this.lastName = _lastname;
    this.password = _password;
    this.userRole = _userRole;
    this.status = _status;
  }
}
