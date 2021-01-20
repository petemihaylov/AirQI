import ***REMOVED*** IMarker***REMOVED*** from "./interfaces/IMarker";

export default class MarkerEntity implements IMarker ***REMOVED***
  name: any;

  id: number | undefined;
  longitude: number | undefined;
  latitude: number | undefined;
  type: string | undefined;
  ico: string | undefined;

  constructor();
  constructor(
    _longitude: number,
    _latitude: number,
    _type: string,
    ico: string,
  );
  constructor(
    _longitude?: number,
    _latitude?: number,
    _type?: string,
    _ico?: string
  ) ***REMOVED***
    this.longitude = _longitude;
    this.latitude = _latitude;
    this.type = _type;
    this.ico = _ico;
 ***REMOVED***
***REMOVED***
