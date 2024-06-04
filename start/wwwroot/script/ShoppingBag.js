window.addEventListener('load', async function () {
    products = JSON.parse(sessionStorage.getItem('basket'));
    showProduct(products)

})
const showProduct = (products) => {
    if (!products || !Array.isArray(products)) {
        return;
    }

    const template = document.getElementById('temp-row');
    const itemsContainer = document.querySelector('.items tbody');

    itemsContainer.innerHTML = ''; // Clear the existing items
    products.forEach(product => {
        const templateContent = document.importNode(template.content, true);
        templateContent.querySelector('.itemName').textContent = product.productName;
        templateContent.querySelector('.itemNumber').textContent = product.quantity;
        templateContent.querySelector('#image').src = product.img;

        const incrementButton = templateContent.querySelector('.incrementButton');
        incrementButton.addEventListener('click', () => {
            updateQuantity(product.productId, 1);
        });

        const decrementButton = templateContent.querySelector('.decrementButton');
        decrementButton.addEventListener('click', () => {
            updateQuantity(product.productId, -1);
        });
        const deleteButton = templateContent.querySelector('.DeleteButton');
        deleteButton.addEventListener('click', () => {
            removeProductFromBasket(product.productId);
        });


        itemsContainer.appendChild(templateContent);
    });

}

const removeProductFromBasket = (productId) => {
    let basket = JSON.parse(sessionStorage.getItem('basket')) || [];
    basket = basket.filter(product => product.productId != productId);
    sessionStorage.setItem('basket', JSON.stringify(basket));
    showProduct(basket);

}
const updateQuantity = (productId, amount) => {
    let basket = JSON.parse(sessionStorage.getItem('basket')) || [];
    const product = basket.find(p => p.productId === productId);

    if (product) {
        product.quantity += amount;
        if (product.quantity < 1) {
            // Ensure the quantity remains positive
            product.quantity = 1;
        }
        sessionStorage.setItem('basket', JSON.stringify(basket));
        showProduct(basket); // Refresh the displayed products after quantity update
    }
}