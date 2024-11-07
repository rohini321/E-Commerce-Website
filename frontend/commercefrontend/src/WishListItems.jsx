import axios from "axios"
import { useEffect, useState } from "react"

function WishListItems()
{
    const [WishListItems,setWishListItems]=useState([]);
    const [AllItems,setAllItems]=useState([{}])

    useEffect(()=>
    {
        axios.get('https://localhost:7293/api/Commerce/GetWishListItems').then((res)=>res.data.map((i)=>setWishListItems(...WishListItems,i.itemId)));
        axios.get('https://localhost:7293/api/Commerce/GetAllItems').then((res)=>setAllItems(res.data))
    })
    return(
        <div>
            {WishListItems.map((Item)=>
            {
                return(
                    <div>
                        <img src={AllItems.filter((i)=>i.itemId==Item.itemId).imageUrl}></img>
                    </div>
                )
            })}
        </div>
    )
}

export default WishListItems