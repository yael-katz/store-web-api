window.addEventListener('load', async function () {
    const userId = Number(JSON.parse(sessionStorage.getItem('user')).userId);
    const url = `http://localhost:5175/api/users/${userId}`;
    try {
        const response = await fetch(url);
        if (response.ok) {
            const user = await response.json();
            document.getElementById('firstName').value = user.firstName;
            document.getElementById('lastName').value = user.lastName;
            document.getElementById('email').value = user.email;
            document.getElementById('password').value = user.password;
        } else {
            console.error('Failed to fetch user data. Status:', response.status);
        }
    } catch (error) {
        console.error('An error occurred while fetching user data:', error);
    }
});

document.getElementById('updateUserForm').addEventListener('submit', async function (event) {
    event.preventDefault();  // Prevent form from submitting the traditional way

    const user = {
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value,
        email: document.getElementById('email').value,
        password: document.getElementById('password').value,
        userId: Number(JSON.parse(sessionStorage.getItem('user')).userId)
    };

    try {
        const res = await fetch('http://localhost:5175/api/users', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        if (res.ok) {
            console.log('User updated:', await res.json());
            document.getElementById('goToProductButton').style.display = 'inline-block'; // Show the button
        } else {
            console.error('Failed to update user. Status:', res.status);
        }
    } catch (error) {
        console.error('Error updating user:', error);
    }
});

function redirectToProductPage() {
    window.location.href = "Products.html"; // Redirect to product.html
}