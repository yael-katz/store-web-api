


const register = async () =>
{
    const FirstName = document.getElementById("firstName").value
    const LastName = document.getElementById("lastName").value
    const Password = document.getElementById("password").value
    const Email = document.getElementById("email").value

    console.log("register");
    const newUser = {
        FirstName,
        LastName,
        Password,
        Email
    }
    console.log(newUser)
    try
    {
        const res = await fetch('api/users/register', {
            method: "POST",
            headers: {
                "Content-Type": 'application/json'
            },
            body: JSON.stringify(newUser)
        })
           console.log("res:   ", res);
        if (res.ok) {
            const user = await res.json();
            sessionStorage.setItem('user', JSON.stringify({ Email, Password,uderId:user.userId}));
             window.location.replace("Products.html")
        }
      
    else
        alert("error, try again")

    }
    catch (e) {
     console.log(e);
      alert("catch")
    }
    
}
const login = async () =>
{
    const Email = document.getElementById("loginEmail").value
    const Password = document.getElementById("loginPassword").value
    const loginUser = { Password, Email }

    console.log(loginUser)
    try {
    const res = await fetch('api/users/login', {
        method: "POST",
        headers: {
            "Content-Type": 'application/json'
        },
        body: JSON.stringify(loginUser)
    })
        
        console.log("res:   ", res);
        if (res.ok) {
            
            const user = await res.json();
            sessionStorage.setItem('user', JSON.stringify({ Email, Password,userId:user.userId}));
            window.location.replace("Products.html")
        }
            
        else
             alert("Unauthorized")

        }
    catch (e) {
        console.log(e);
        alert("catch")
    }

   
}
const  checkPassword = async () =>
{
    const password = document.getElementById("password").value


    try {
        const res = await fetch('api/users/password', {
            method: "POST",
            headers: {
                "Content-Type": 'application/json'
            },
            body: JSON.stringify(password)
        })

        console.log("res:   ", res);
        if (res.ok) {
            const passwordInput = document.getElementById("password");
            const score = await res.json(); // Assuming score is fetched here
            if (score < 2) {
                passwordInput.style.backgroundColor = 'red';
            } else if (score >= 2 && score < 4) {
                passwordInput.style.backgroundColor = 'green';
            } else {
                passwordInput.style.backgroundColor = 'yellow';
            }
        }
        else
            alert("worng1")
    }
    catch (e) {
    
        alert("worng catch")
    }
}

