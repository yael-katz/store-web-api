window.addEventListener('load',  function () {
     loadProduct();
    loadCategories();

})
let products = [];
const loadProduct = async () => {
    try {
        const res = await fetch('api/products', {
            method: "GET",
            headers: {
                'Cache-Control': 'no-cache'
            }
        })

        if (res.ok) {
            let products = await res.json()
            showProduct(products);
        }
        else
            alert("error, try again product")
    }
    catch (e) {
        alert("catch")
    }
}

const clearProductList1 = () => {
    const contentDiv = document.getElementById('PoductList');
    contentDiv.innerHTML = '';
}

const showProduct = (products) => {

    const contentDiv = document.getElementById('PoductList');
    contentDiv.innerHTML = '';
    products?.map(p => {
        // Get the template element
        const template = document.getElementById('temp-card');

        // Clone the template content
        const clone = document.importNode(template.content, true);

        // Update the cloned content with specific data
        let h1 = clone.querySelector('h1');
        h1.id = p.productId
        h1.textContent = p.productName
        let price = clone.querySelector('.price');
        price.textContent = p.price
        let description = clone.querySelector('.description');
        description.textContent = p.description
        let image = clone.querySelector('#image');
        image.src = p.img
        // Add an event listener to the button (assuming you want to do something when the button is clicked)
        const button = clone.querySelector('button');
        button.addEventListener('click', function (e) {
            // Add to cart logic here

            addItemToBasket(h1.id, h1.innerHTML, price.innerHTML, description.innerHTML, image.src)
        });
        const ProductsList = document.getElementById('PoductList');
        // Append the cloned template to the document
        ProductsList.appendChild(clone);
    }
    )
}

const loadCategories = async () => {
    try {
        const res = await fetch('api/categories', {
            method: "GET",
            headers: {
                'Cache-Control': 'no-cache'
            }
        });
        debugger

        if (res.ok) {
            const categories = await res.json();
            showCategories(categories);
        }
        else {
            console.error("Server error:", res.status, res.statusText);
            alert("Server error:", res.status, res.statusText);
        }
    } catch (e) {
        console.error("Network or other error:", e);
        alert("An error occurred while loading categories. Please try again.");
    }
    return [];
}

const filterProductsByName = () => {
    const str = document.getElementById('nameSearch').value
    const findProduct = products.filter(product => product.productName.toLowerCase().includes(str.toLowerCase()));
    showProduct(findProduct)
}


const showCategories = async (categories) => {

    const checkboxContainer = document.getElementById('checkboxContainer');

    const productsContainer = document.getElementById('productsContainer');

    categories?.map(category => {
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        checkbox.id = category.categoryId;
        checkbox.name = 'category';
        checkbox.value = category.categotyName;

        const label = document.createElement('label');
        label.htmlFor = category.categotyName;
        label.textContent = category.categotyName;

        checkboxContainer.appendChild(checkbox);
        checkboxContainer.appendChild(label);
        checkboxContainer.appendChild(document.createElement('br'));

        checkbox.addEventListener('change', () => {
            productFilter()
        })
    });

}
const productFilter = async () => {
    const selectedCategories = [...document.querySelectorAll('input[name="category"]:checked')].map(checkbox => checkbox.id);
    console.log(selectedCategories)
    let stringQuery = ''
    if (selectedCategories.length > 0)
        stringQuery = selectedCategories.reduce((a, b) => `${a}categoryIds=${b}&`, '')
    console.log(stringQuery)
    if (document.getElementById('minPrice').value != '')
        stringQuery += `minPrice=${document.getElementById('minPrice').value}`
    if (document.getElementById('maxPrice').value != '')
        stringQuery += `&maxPrice=${document.getElementById('maxPrice').value}`
    try {
        const res = await fetch(`api/products?${stringQuery}`, {
            method: "GET",
            headers: {
                'Cache-Control': 'no-cache'
            }
        })
        if (res.ok) {
            products = await res.json()
            filterProductsByName()

        }
        else
            alert("error, try again")
    }
    catch (e) {
        alert("catch")
    }
}


const addItemToBasket = (productId, productName, price, description, img) => {

    let basket = JSON.parse(sessionStorage.getItem('basket')) || [];

    const existingProductIndex = basket.findIndex(product => product.productId === productId)

    if (existingProductIndex !== -1) {
        // If the product already exists in the basket, increase the quantity
        basket[existingProductIndex].quantity += 1;
    } else {
        // If the product is not in the basket, add it with quantity 1
        basket.push({ productId, quantity: 1, productName, price, description, img });
    }

    sessionStorage.setItem('basket', JSON.stringify(basket));
};
