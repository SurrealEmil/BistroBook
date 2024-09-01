# BistroBook
In this task, I will develop a backend system to manage reservations, customer information, and menus for a restaurant. 
The system will enable the management of tables, bookings, customers, and menus through a Web API, allowing the restaurant to efficiently administer its resources.

## Table of Contents
- [Endpoints](#endpoints)
  - [Customers](#customer)
  - [Menus](#menu)
  - [Reservations](#reservation)
  - [Tables](#table)
 
  # Endpoints
 
## Customer
#### `Post /api/Customers/AddCustomer`
- **Purpose**: Adds a new customer.
- **Request Body**:
  ```json
  {
    "phoneNumber": "0727022883",
    "email": "Anton.StenBerg@gmail.com",
    "firstName": "Anton",
    "lastName": "StenBerg"
  }
  ```
- **Response**:
  - 200 OK: Customer added successfully.
  - 400: {ex.Message}

#### `Get /api/Customers/GetAllCustomers`
- **Purpose**: Retrieves a list of all customers in the system.
- **Response**:
  - 200 OK:
  ```json
  {
    "customerId": 1,
    "email": "Jan.Eriksson@gmail.com",
    "lastName": "Eriksson"
  },
  {
    "customerId": 2,
    "email": "Johan.Anderson@gmail.com",
    "lastName": "Anderson"
  },
  {
    "customerId": 3,
    "email": "Anton.StenBerg@gmail.com",
    "lastName": "StenBerg"
  }
  ```
  - 404 Not found: No customers found.

#### `Get /api/Customers/GetCustomerById/{id}`
- **Purpose**: Retrieves detailed information for a specific customer identified by {id}.
- **Response**:
  - 200 OK:
  ```json
  {
    "customerId": 3,
    "phoneNumber": "0727022883",
    "email": "Anton.StenBerg@gmail.com",
    "firstName": "Anton",
    "lastName": "StenBerg"
  }
  ```
  - 404 Not found: No matching customer found.
    
#### `Put /api/Customers/UpdateCustomer/{id}`
- **Purpose**: Updates the details of an existing customer identified by {id}.
- **Request Body**:
  ```json
  {
    "phoneNumber": "0727022883",
    "email": "Anton.StenBerg@gmail.com",
    "firstName": "Anton",
    "lastName": "StenBerg"
  }
  ```
- **Response**:
  - 200 OK: Customer updated successfully.
  - 400: {ex.Message}
    
#### `DELETE /api/Customers/DeleteCustomer/{id}`
- **Purpose**: Deletes the customer identified by {id} from the system.
- **Response**:
  - 200 OK: Customer deleted successfully.
  - 400: {ex.Message}

## Menu
#### `Post /api/Menus/AddDish`
- **Purpose**: Adds a new dish to the menu.
- **Request Body**:
  ```json
  {
    "price": 140,
    "dishName": "Creamy Mushroom Pasta",
    "description": "Tagliatelle pasta tossed in a creamy mushroom sauce with a hint of garlic and Parmesan.",
    "isAvailable": true
  }
  ```
- **Response**:
  - 200 OK: Dish added successfully..
  - 400: {ex.Message}
    
#### `Get /api/Menus/GetAllMenuDishes`
- **Purpose**: Retrieves a list of all dishes in the system.
- **Response**:
  - 200 OK:
  ```json
  {
    "menuId": 1,
    "price": 120,
    "dishName": "Swedish Meatballs",
    "isAvailable": true
  },
  {
    "menuId": 2,
    "price": 180,
    "dishName": "Grilled Salmon Fillet",
    "isAvailable": true
  },
  {
    "menuId": 3,
    "price": 140,
    "dishName": "Creamy Mushroom Pasta",
    "isAvailable": true
  }
  ```
  - 404 Not Found: No dish found.
    
#### `Get /api/Menus/GetDishById/{id}`
- **Purpose**: Retrieves detailed information for a specific dish identified by {id}.
- **Request Body**:
  - 200 OK:
  ```json
  {
    "menuId": 3,
    "price": 140,
    "dishName": "Creamy Mushroom Pasta",
    "description": "Tagliatelle pasta tossed in a creamy mushroom sauce with a hint of garlic and Parmesan.",
    "isAvailable": true
  }
  ```
  - 404 Not Found: No matching dish found.
    
#### `Put /api/Menus/UpdateMenu/{id}`
- **Purpose**: Updates the details of an existing dish identified by {id}.
- **Request Body**:
  ```json
  {
    "price": 140,
    "dishName": "Creamy Mushroom Pasta",
    "description": "Tagliatelle pasta tossed in a creamy mushroom sauce with a hint of garlic and Parmesan.",
    "isAvailable": true
  }
  ```
- **Response**:
  - 200 OK: Menu updated successfully.
  - 400: {ex.Message}
    
#### `Delete /api/Menus/DeleteDish/{id}`
- **Purpose**: Deletes a dish identified by {id} from the system.
- **Response**:
  - 200 OK: Dish deleted successfully.
  - 400: {ex.Message}
    
## Reservation
#### `Post /api/Reservations/AddReservation`
- **Purpose**: Adds a new reservation that connects a customer with a table.
- **Request Body**:
  ```json
  {
    "customerId": 1,
    "tableId": 2,
    "guestCount": 2,
    "date": "2024-08-30",
    "startTime": "18:00:00",
    "endTime": "19:00:00"
  }
  ```
  - **Response**:
  - 200 OK: Reservation added successfully.
  - 400: {ex.Message}
    
#### `Get /api/Reservations/GetAllReservations`
- **Purpose**: Retrieves a list of all reservations in the system.
- **Response**:
  - 200 OK:
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "tableId": 1,
    "customerFullName": "Jan Eriksson",
    "tableNumber": 1,
    "date": "2024-08-29T00:00:00",
    "startTime": "18:00:00",
    "endTime": "19:00:00"
  },
  {
    "reservationId": 2,
    "customerId": 2,
    "tableId": 2,
    "customerFullName": "Johan Anderson",
    "tableNumber": 2,
    "date": "2024-08-30T00:00:00",
    "startTime": "20:00:00",
    "endTime": "21:00:00"
  }
  ```
  - 404 Not Found: No reservations found.
    
#### `GET: api/Reservations/GetReservationsByCustomerId/{id}`
- **Purpose**: Retrieves all reservations associated with a specific customer by their {id}.
- **Response**:
  - 200 OK:
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "tableId": 1,
    "customerFullName": "Jan Eriksson",
    "tableNumber": 1,
    "date": "2024-08-29T00:00:00",
    "startTime": "18:00:00",
    "endTime": "19:00:00"
  }
  ```
  - 404 Not Found: No reservations found.
    
#### `GET: api/Reservations/GetReservationsByTableId/{id}`
- **Purpose**: Retrieves all reservations associated with a specific table by their {id}.
- **Response**:
  - 200 OK: 
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "tableId": 1,
    "customerFullName": "Jan Eriksson",
    "tableNumber": 1,
    "date": "2024-08-29T00:00:00",
    "startTime": "18:00:00",
    "endTime": "19:00:00"
  }
  ```
  - 404 Not Found: No reservations found.
    
#### `GET: api/Reservations/GetReservationsByDate/2024-08-30`
- **Purpose**: Retrieves all reservations associated with a specific date.
- **Response**:
  -200 OK: 
  ```json
  {
    "reservationId": 2,
    "customerId": 2,
    "tableId": 2,
    "customerFullName": "Johan Anderson",
    "tableNumber": 2,
    "date": "2024-08-30T00:00:00",
    "startTime": "20:00:00",
    "endTime": "21:00:00"
  }
  ```
  - 404 Not Found: No reservations found.
    
#### `Get /api/Reservations/GetReservationById/{id}`
- **Purpose**: Retrieves detailed information for a specific reservation identified by {id}
- **Request Body**:
  -  200 OK: 
  ```json
  {
    "reservationId": 3,
    "tableId": 2,
    "tableNumber": 2,
    "customerId": 1,
    "guestCount": 2,
    "customerFullName": "Jan Eriksson",
    "date": "2024-08-30T00:00:00",
    "startTime": "18:00:00",
    "endTime": "19:00:00"
  }
  ```
  - 404 Not Found: No matching reservation found.
    
#### `Put /api/Reservations/UpdateReservation/{id}`
- **Purpose**: Updates the details of an existing reservation identified by {id}.
- **Request Body**:
  ```json
  {
    "customerId": 1,
    "tableId": 2,
    "guestCount": 2,
    "date": "2024-08-30",
    "startTime": "18:00:00",
    "endTime": "19:00:00"
  }
  ```
- **Response**:
  - 200 OK: Reservation updated successfully.
  - 400: {ex.Message}
    
#### `Delete /api/Reservations/DeleteReservation/{id}`
- **Purpose**: Deletes a reservation identified by {id} from the system.
- **Response**:
  - 200 OK: Reservation deleted successfully.
  - 400: {ex.Message}

## Table
#### `Post /api/Tables/AddTable`
- **Purpose**: Adds a new table.
- **Request Body**:
  ```json
  {
    "seatCount": 8,
    "tableNumber": 10
  }
  ```
- **Response**:
  - 200 OK: Table added successfully.
  - 400: {ex.Message}
    
#### `Get /api/Tables/GetAllTables`
- **Purpose**: Retrieves a list of all tables in the system.
- **Response**:
  - 200 OK:
  ```json
  {
    "tableId": 1,
    "seatCount": 4,
    "tableNumber": 1
  },
  {
    "tableId": 2,
    "seatCount": 6,
    "tableNumber": 2
  },
  {
    "tableId": 3,
    "seatCount": 2,
    "tableNumber": 3
  }
  ```
  - 404 Not Found: No tables found.
    
 #### `Get /api/Tables/GetTableById/{id}`
- **Purpose**: Retrieves detailed information for a specific table identified by {id}.
- **Request Body**:
  - 200 OK:
  ```json
  {
    "tableId": 1,
    "seatCount": 4,
    "tableNumber": 1
  }
  ```
  - 404 Not Found: No matching table found.
    
#### `Put /api/Tables/UpdateTable/{id}`
- **Purpose**:  Updates the details of an existing table identified by {id}.
- **Request Body**:
  ```json
  {
    "seatCount": 8,
    "tableNumber": 10
  }
  ```
- **Response**:
  - 200 OK: Table updated successfully.
  - 400: {ex.Message}
    
#### `Delete /api/Tables/DeleteTable/{id}`
- **Purpose**: Deletes the table identified by {id} from the system.
- **Response**:
  - 200 OK: Table deleted successfully.
  - 400: {ex.Message}
