let form = document.getElementById("form");
let input = document.getElementById("input");
let msg = document.getElementById("msg");
let posts = document.getElementById("posts");

form.addEventListener("submit", (e) => {
  e.preventDefault();
  formValidation();
});

let formValidation = () => {
  if (input.value.trim() === "") {
    msg.innerHTML = "El post no puede estar en blanco";
  } else if (input.value.length > 255) {
    msg.innerHTML = "El post excede el límite de 255 caracteres";
  } else {
    msg.innerHTML = "";
    acceptData();
  }
};

let acceptData = () => {
  let postData = input.value.trim();
  createPost(postData);
  input.value = "";
};

let createPost = (postData) => {
  let postElement = document.createElement("div");
  postElement.innerHTML = `
    <p>${postData}</p>
    <span class="options">
      <i onClick="editPost(this)" class="fas fa-edit"></i>
      <i onClick="deletePost(this)" class="fas fa-trash-alt"></i>
    </span>
  `;
  posts.appendChild(postElement);
};

let deletePost = (element) => {
  element.parentElement.parentElement.remove();
};

let editPost = (element) => {
  let postText = element.parentElement.previousElementSibling.innerHTML;
  input.value = postText;
  element.parentElement.parentElement.remove();
};
