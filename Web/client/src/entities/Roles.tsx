type EnumLiteralsOf<T extends object> = T[keyof T];

export type Roles = EnumLiteralsOf<typeof Roles>;

const Roles = Object.freeze(***REMOVED***
    Admin: 'Admin' as 'Admin',
    Moderator: 'Moderator' as 'Moderator',
    User: 'User' as 'User'
***REMOVED***);

export default Roles;