import "./HomePage.css"
import AllItems from "./AllItems"
function HomePage()
{

    return(
        <div>
            <head>
                <link rel="stylesheet" 
                href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css" 
                integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg==" 
                crossorigin="anonymous" 
                referrerpolicy="no-referrer" />
            </head>
            <nav className="HomeNav">
                <div className="SearchDiv">
                <i class="fa-solid fa-magnifying-glass"></i>
                    <input type="text" className="SearchInput" placeholder="Search any product"></input>
                </div>
                  <i class="fa-solid fa-heart"></i>
                  <i class="fa-solid fa-cart-shopping"></i>
                  <button>Signup</button>
                  <button>Login</button>
            </nav>
            <main>
                <AllItems />
            </main>
        </div>
    )
}

export default HomePage