# ProductList

## 📌 Project Overview
ProductList is a **C# console application** designed to handle structured product inputs while ensuring **strict validation** based on defined rules. This project follows **Uncle Bob’s Clean Code principles**, making it **maintainable, scalable, and readable**.

### Features
- Accepts product names in the format `NAME-XXX`, where:
  - `NAME` contains **only letters** (A-Z, a-z) and is **max 4 characters long**.
  - `XXX` is a **3-digit number** between **200-500**.
- **Strict validation** with clear error messages.

---

### Logic & Readability
This application is built with a strong focus on **readability and structured logic**:
1. The user enters a **product name** following the format `NAME-XXX` (e.g., `CE-400`).
2. The input is **trimmed and validated** to ensure it follows the correct structure:
   - `NAME` contains only letters and is **max 4 characters long**.
   - `XXX` is a **3-digit number** between **200-500**.
3. If validation **fails**, a **specific error message** is displayed.
4. If the input is **valid**, the product is **dynamically stored**.
5. The list is **sorted alphabetically** and displayed at the end.
6. **Color-coded messages** enhance the user experience.

---

## How to Run
### 1. Clone the Repository
### 2. Run the Application
### 3. Enter Product Names
Input product names following the format `NAME-XXX` (e.g., `CE-400`).
Type `exit` to display the **sorted product list**.

---

## Future Enhancements
- **Unit tests** for validation functions.

---

## Author
Developed by **Jonni Akesson** as part of **Lexicon C# Course**, with a focus on **Clean Code & Best Practices**.