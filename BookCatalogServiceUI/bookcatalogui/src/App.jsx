import React, { useState } from 'react';
import { Container, Grid } from '@mui/material';
/* import books from './data/book'; */
import BookCard from './components/BookCard';
import Header from './components/Header';
import { useEffect } from 'react';

function App() {
  const [cart, setCart] = useState([]);
  const [books, setBook] = useState([]);

  useEffect(() => {
    fetch('https://group35-bookservice-htdtckgzazdefke9.southindia-01.azurewebsites.net/api/BookCatalog')
      .then((response) => response.json())
      .then((json) => {
        setBook(json);
      })
      .catch((err) => {
      });
  }, []);

  const addToCart = (book) => {
    setCart([...cart, book]);
  };

  return (
    <>
      <Header cartCount={cart.length} />
      <Container sx={{ mt: 4 }}>
        <Grid container spacing={2}>
          {books.map((book) => (
            <Grid item key={book.id}>
              <BookCard book={book} addToCart={addToCart} />
            </Grid>
          ))}
        </Grid>
      </Container>
    </>
  );
}

export default App;
