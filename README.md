### What's Left to Do

* Add endpoints for refresh tokens
* Wrap everything in async/task - as I used json for my database with synchronoous methods there was not much point but in real life everything should be asynchronous
* Add DTOs/Mappers.
* Properly handle object primary keys (especially in my creates/updates).

### Remarks

* Basket and Wishlist should be different endpoints/classes.
* Users list should store product IDs, not product objects.
* A user email is not a good primary key for a UserList if:
    1.  A user who isn't logged in should still be able to have a basket.
    2.  A user should be able to have multiple wishlists.
