import { INotification } from "./INotification";

export default class Notification implements INotification {
  name: any;

  id: number | undefined;
  username: string | undefined;
  title: string | undefined;
  description: string | undefined;
  createdAt: string | undefined;

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
    _title?: string,
    _description?: string,
    _createAt?: string,
  ) {
    this.username = _username;
    this.title = _title;
    this.description = _description;
    this.createdAt = _createAt;
  }
}
