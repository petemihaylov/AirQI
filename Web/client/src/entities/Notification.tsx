import { INotification } from "./INotification";

export default class Notification implements INotification {
  name: any;

  id: number | undefined;
  title: string | undefined;
  description: string | undefined;
  type: string | undefined;
  createdAt: string | undefined;

  constructor();
  constructor(
   _title: string,
   _description: string,
   _typs: string,
   _createdAt: string
  );
  constructor(
    _title?: string,
    _description?: string,
    _type?: string,
    _createAt?: string,
  ) {
    this.title = _title;
    this.description = _description;
    this.type = _type;
    this.createdAt = _createAt;
  }
}
