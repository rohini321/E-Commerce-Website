import { useEffect, useState } from "react"
import './AllItems.css'
import axios from 'axios'

function AllItems()
{
    const [Items,SetItems]=useState([{}])
   // const WishListItems=[]
    const [WishListItems,setWishListItems]=useState([])
    useEffect(()=>
    {
        const fetchData=async()=>{
        axios.get('https://localhost:7293/api/Commerce/GetAllItems').then((res)=>SetItems(res.data));
        //console.log(Items)

        axios.get('https://localhost:7293/api/Commerce/GetWishListItems')
        .then((res)=>{
            const ItemIds= res.data.map((i)=>i.itemId);
            //we  are getting all the ItemIds which are stored as array and finally setting to wishListItems using  setWishListItems(ItemIds)
            setWishListItems(ItemIds)});
    
        console.log(WishListItems)
        }
        fetchData();
    },[]);
    const AddOrRemoveFromWishList=(Item)=>
    {
        console.log(WishListItems)
       // console.log(Item.itemId);
        if(!WishListItems.includes(Item.itemId))
        {
            console.log('hi')
            axios.post('https://localhost:7293/api/Commerce/AddToWishList',{
                id: 0,
                itemId: Item.itemId,
                userId: 5
            }).then((res)=>console.log(res.data))
        }
        else 
        {
            axios.delete('https://localhost:7293/api/Commerce/RemoveFromWishList',{params:{ItemId:Item.itemId}})
        }
    }
    return (
        <div className="AllItems">
            <head>
            <link rel="stylesheet"
            href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css" 
            integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg==" 
            crossorigin="anonymous" 
            referrerpolicy="no-referrer" />
            </head>
        {Items.map((Item)=>{
            return(
                <div>
                    <img style={{width:'150px',height:'150px',display:"block"}} src={Item.imageUrl} ></img>
                    <h3 style={{display:"inline"}}>{Item.name}</h3> &nbsp;&nbsp;&nbsp;
                    <i class="fa-solid fa-heart"
                            onClick={()=>AddOrRemoveFromWishList(Item)} 
                            style={WishListItems.includes(Item.itemId)?{color:'red'} :{color:'black'}}></i>
                    <p>{Item.description}</p>
                    <h4>{Item.price}</h4>
                </div>
            )
        })} 
        </div>
    )
}

export default AllItems