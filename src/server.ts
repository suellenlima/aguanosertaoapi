import dotenv from 'dotenv';
import express from 'express';
import './database';

dotenv.config();

const app = express();

// app.get('/', (request, response) => {
//     return response.json({ message: 'Hello Sertão!'});
// })

app.listen(3333, () => {
    console.log('🚀 Server started on port 3333!');
})
