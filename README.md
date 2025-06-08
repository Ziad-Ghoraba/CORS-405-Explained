# CORS-405-Explained

This repository provides a simple demonstration and explanation of two common web development challenges:

- **HTTP 405 Method Not Allowed errors** — occur when a client tries to use an HTTP method (GET, POST, PUT, etc.) that the server does not allow for a specific endpoint.  
- **CORS (Cross-Origin Resource Sharing) issues** — happen when a frontend application running on one origin tries to make requests to a backend on another origin, but the backend does not permit those cross-origin requests.

---

## How to Run This CORS Example

### Backend Setup (ASP.NET Core MVC)

1. Open the `Program.cs` file and find this part:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")  // <-- Change this to your frontend URL
              .WithHeaders("Content-Type", "Authorization", "X-Requested-With")
              .WithMethods("GET", "POST", "PUT");
    });
});
```
2. Change the URL inside `.WithOrigins(...)` to the address where your frontend page will run. For example:

- If you use VSCode Live Server, it’s usually `http://127.0.0.1:5500`
- Make sure **only** the origin (protocol + domain + port) is included — no file paths!

3. Run the backend with:

```bash
dotnet run
```
It will start on `https://localhost:7076` by default.

---

### Frontend Setup (HTML + Fetch)

1. Open the HTML file that sends the fetch request:

```js
fetch("https://localhost:7076", {
  method: "POST",
  headers: {
    "Content-Type": "application/json",
    Authorization: "Bearer YOUR_TOKEN_HERE",
    "X-Requested-With": "XMLHttpRequest",
  },
  body: JSON.stringify({ message: "Hello from frontend" }),
})
```
2. Make sure the fetch URL matches your backend URL.

3. Serve your HTML page on the same origin you used in `.WithOrigins(...)`, for example using Live Server or any simple HTTP server.

---

### Test It

- Open your frontend page in the browser.
- Click the button to send the request.
- You should see a response from the backend if CORS is configured correctly.
- If not, check your console for CORS errors.

---


**Tip:** CORS requires the backend to explicitly allow your frontend’s origin, methods, and headers — otherwise the browser blocks the request.

---

Let me know if you want me to add anything else!
