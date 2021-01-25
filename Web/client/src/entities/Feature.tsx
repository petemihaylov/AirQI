import Geometry from "./Geometry";

export default class Feature {
  type: string | undefined;
  properties: string | undefined;
  geometry: Geometry | undefined;

  
  constructor(
    _type?: string,
    _properties?: string,
    _geometry?: Geometry
  ) {
    this.type = _type;
    this.properties = _properties;
    this.geometry = _geometry;
  }
}
