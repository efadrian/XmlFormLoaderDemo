### Xml Form Loader Demo

- XML Form Demo with controllers:
- Form -> XML Data
    - GetForm - Loads xml form data for 3 countries : UK, DE, ES
    - GetPayments - Loads xml payments
- User -> CRUD Operations
  - GetAllUserAddresses
  - CreateUserAddress
  - UpdateUserAddress
  - DeleteUserAddress
  
- Db Setup : EF Migration for table Addresses
  Add-Migration "XMLDemo"
  Update-Database
