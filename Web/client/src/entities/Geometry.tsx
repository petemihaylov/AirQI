export default class Geometry {
  type: string | undefined;
  cordinates: number[][] | undefined;

    constructor(
    _type?: string,
    _cordinates?: number[][]
  ) {
    this.type = _type;
    this.cordinates = _cordinates;
  }
}
