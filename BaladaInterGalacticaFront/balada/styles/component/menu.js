import React from 'react'
import '../Home.module.css';

const Menu = () =>

<div className="inputMenu">
<input type="checkbox" id="menu"/>
<label htmlFor="menu">
    <div className="menuImg"></div>
</label> 


    <div className="menu"> 
            <nav>
                <ul id="">
                    <li> <a href="http://localhost:3000">Home</a> </li>
                    <li> <a href="alien">Alien</a> </li>
                    <li> <a href="ballad">Balada</a> </li>
                    <li> <a href="checkIn">Check In</a> </li>
                    <li> <a href="checkOut">Check Out</a> </li>
                    <li> <a href="objectNotAllowed">Objeto Proibido</a> </li>
                    <li> <a href="help">Help</a> </li>
                </ul>
            </nav>
    </div>  
</div>

export default Menu;