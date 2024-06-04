
window.addEventListener('load', async function () {
    console.log("hello")
    let price = 0;
    JSON.parse(sessionStorage.getItem('basket')).map(p => price = price + p.price * p.quantity )
    document.getElementById("price").innerHTML = price;
    document.getElementById("date").innerHTML = new Date().toLocaleString('en-GB', { day: '2-digit', month: '2-digit', year: '2-digit' });

})

const confirmOrder = async () =>
{
    let price = 0;
    const OrderItems = JSON.parse(sessionStorage.getItem('basket')).map(p => {
        price = price + p.price*p.quantity
        return {
            Quantity: p.quantity,
            ProductId: p.productId
        }
    })
    console.log(price)
    const User = JSON.parse(sessionStorage.getItem('user'));
    debugger
    try
    {
        const res = await fetch('api/orders',
        {
            method: "POST",
            headers: {
                "Content-Type": 'application/json'
            },
            body: JSON.stringify({ OrderSum:price,OrderItems,UserId:User.userId })   
        })
        console.log("res:   ", res);
        if (res.ok) {
            
            sessionStorage.setItem("basket",[])
            window.location.replace("final.html");
        }

        else
            alert("error, try again")

    }
    catch (e) {
        alert("catch")
    }
}


const cancelOrder = () => {
    window.location.replace("ShoppingBag.html")
}