import { ISlaMarker } from "./ISlaMarker";

export default class SlaMarker implements ISlaMarker {
  id: number | undefined;
  name: string | undefined;
  count: number | undefined;
  maxValue: number | undefined;
  locationBoundaries: string | undefined;

  constructor();
  constructor(
    _name: string,
    _count: number,
    _maxValue: number,
    _locationBoundaries: string
  );
  constructor(
    _name?: string,
    _count?: number,
    _maxValue?: number,
    _locationBoundaries?: string
  ) {
    this.name = _name;
    this.count = _count;
    this.maxValue = _maxValue;
    this.locationBoundaries = _locationBoundaries;
  }
}
