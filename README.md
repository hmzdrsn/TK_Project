
# Api Endpoints


•	Auth
  o	POST /api/Auth/Login
  o	POST /api/Auth/Register
•	User
  o	GET/api/User/GetAll	
  o	GET /api/User/GetByID	(ADMIN ,MEMBER)
  o	POST/api/User/AddUser	 (ADMIN)
  o	PUT /api/User/UpdateUser	(ADMIN)
  o	DELETE /api/User/DeleteUser	(ADMIN)
•	Role
  o	GET /api/Role/GetAll	
  o	POST /api/Role/AddRole	(ADMIN)
  o	PUT /api/Role/UpdateRole	(ADMIN)
  o	DELETE /api/Role/DeleteRole	(ADMIN)
  o	PUT /api/Role/AssignRole	(ADMIN)
•	Category
  o	GET/api/Category /GetAll	
  o	GET /api/Category /GetByID	(ADMIN ,MEMBER)
  o	POST /api/Category /AddCategory	(ADMIN)
  o	PUT /api/Category /UpdateCategory	(ADMIN)
  o	DELETE /api/Category /DeleteCategory	(ADMIN)
•	Product
  o	GET /api/Product/GetAll	
  o	GET /api/Product/GetByID	(ADMIN ,MEMBER)
  o	GET /api/Product/GetProductsByCategory (ADMIN ,MEMBER)
  o	POST /api/Product/AddProduct	(ADMIN)
  o	PUT /api/Product/UpdateProduct	(ADMIN)
  o	DELETE /api/Product/DeleteProduct	(ADMIN)
•	Order
  o	GET /api/Order/GetAll
  o	GET /api/Order/GetByID	(ADMIN ,MEMBER)
  o	POST /api/Order/AddOrder	(ADMIN)
  o	PUT /api/Order/UpdateOrder	(ADMIN)
  o	DELETE /api/Order/DeleteOrder	(ADMIN)
•	Mail
  o	POST /api/Mail/ReceiveAndSendMail	(ADMIN)
  o	POST /api/Mail/SendMessageToQueue	(ADMIN ,MEMBER)
  o	POST /api/Mail/SendMail	(ADMIN ,MEMBER)
