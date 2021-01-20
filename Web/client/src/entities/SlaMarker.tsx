import ***REMOVED*** ISlaMarker***REMOVED*** from "./interfaces/ISlaMarker";

export default class SlaMarker implements ISlaMarker ***REMOVED***
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
  ) ***REMOVED***
    this.name = _name;
    this.count = _count;
    this.maxValue = _maxValue;
    this.locationBoundaries = _locationBoundaries;
 ***REMOVED***
***REMOVED***
