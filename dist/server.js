"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const dotenv_1 = __importDefault(require("dotenv"));
const express_1 = __importDefault(require("express"));
require("./database");
dotenv_1.default.config();
const app = (0, express_1.default)();
app.get('/', (request, response) => {
    return response.json({ message: 'Hello Sertão!' });
});
app.listen(3333, () => {
    console.log('🚀 Server started on port 3333!');
});
