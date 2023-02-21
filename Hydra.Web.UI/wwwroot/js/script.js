(function () {
  if(sessionStorage.getItem("success") != null){
      console.log(sessionStorage.getItem("success"));
      $(".modal-body > h2").html(sessionStorage.getItem("success"));
      $(".modal-message").show();
  }
})();

const modal = document.querySelector(".modal");
const BASE_URL = "http://localhost:8070";

$(".cancel-modal").click(function (event) {
    $(".modal-static").hide();
    $(".modal").hide();
    sessionStorage.clear();
});

document.addEventListener("click", (event) => {
    if (event.target == modal) {
      modal.style.display = "none";
      sessionStorage.clear();
    }
});

//inventory

$(".btn-new-inventory").click(function (event) {
  $("#name").attr('readonly', false);
  $(".modal-body > h2").html("Insert New Inventory");
  $(".upsert-new-inventory").html("Simpan");
  $("#name").val("");
  $("#description").val("");
  $("#stock").val("");
  $(".modal-new-inventory").show();
});
$(".btn-edit-inventory").click(function (event) {
  const name = $(this).data("name");
  $.ajax({
      method: "GET",
      url: BASE_URL+"/api/inventory/"+name,
      contentType: "application/json",
      success: function (response) {
          $("#name").attr('readonly', true),
          $("#name").val(response.name),
          $("#description").val(response.description),
          $("#stock").val(response.stock)
          $(".modal-body > h2").html("Update Inventory");
          $(".upsert-new-inventory").html("Ubah");
          $(".modal-new-inventory").show();
      },
  });
});
$(".upsert-new-inventory").click(function (event) {
    let dto = {
        name: $("#name").val(),
        description: $("#description").val(),
        stock: $("#stock").val()
    };
    $.ajax({
        method: "PUT",
        url: BASE_URL+"/api/inventory",
        data: JSON.stringify(dto),
        contentType: "application/json",
        success: function (response) {
            const message = "Data inventory "+response.name+" berhasil disave.";
            sessionStorage.setItem("success", message);
            location.reload();
        },
    });
});

$(".btn-delete-inventory").click(function (event) {
  const name = $(this).data("name");
  $(".delete-inventory").data('name', name);
  $(".modal-body > h2").html("Apakah anda yakin ingin menghapus "+name+"?");
  $(".modal-delete-inventory").show();
});

$(".delete-inventory").click(function (event) {
    const name = $(this).data("name");
    $.ajax({
      method: "DELETE",
      url: BASE_URL+"/api/inventory/"+name,
      contentType: "application/json",
      success: function (response) {
        sessionStorage.setItem("success", response);
        location.reload();
      },
    });
});

//Admin
$(".btn-new-admin").click(function (event) {
  $("#username").attr('readonly', false);
  $(".modal-body > h2").html("Insert New Admin");
  $(".btn-save").html("Simpan");
  $(".btn-save").addClass("insert-new-admin");
  $("#username").val("");
  $("#job-title").val("");
  $(".modal-new-admin").show();
});

$(".btn-edit-admin").click(function (event) {
  const username = $(this).data("username");
  $.ajax({
      method: "GET",
      url: BASE_URL+"/api/admin/"+username,
      contentType: "application/json",
      success: function (response) {
          $("#username").attr('readonly', true),
          $("#username").val(response.username),
          $("#job-title").val(response.jobTitle),
          $(".modal-body > h2").html("Update Admin");
          $(".btn-save").html("Ubah");
          $(".btn-save").addClass("update-admin");
          $(".modal-new-admin").show();
      },
  });
});
$(document).on("click",".insert-new-admin",function (event) {
    let dto = {
        username: $("#username").val(),
        password: null,
        jobTitle:  $("#job-title").val(),
    }
    $.ajax({
          method: "POST",
          url: BASE_URL+"/api/admin",
          data: JSON.stringify(dto),
          contentType: "application/json",
          success: function (response) {
              const message = "Data dengan username "+response.username+" berhasil ditambahkan.";
              sessionStorage.setItem("success", message);
              location.reload();
          },
      });
});
$(document).on("click",".update-admin",function (event) {
    let dto = {
        username: $("#username").val(),
        jobTitle:  $("#job-title").val(),
    }
    $.ajax({
          method: "PATCH",
          url: BASE_URL+"/api/admin",
          data: JSON.stringify(dto),
          contentType: "application/json",
          success: function (response) {
              const message = "Data dengan username "+response.username+" berhasil diubah.";
              sessionStorage.setItem("success", message);
              location.reload();
          },
      });
});
//Admin
//room item
$(".add-new-item").click(function(event){
    const roomNumber = $(this).data("number");
    $.ajax({
        method: "GET",
        url: BASE_URL+"/api/inventory/dropdown",
        contentType: "application/json",
        success: function (response) {
             $(".modal-insert-item").show();
             $('.inventory-dropdown').empty();
             $('.inventory-dropdown').append($("<select>"));
             $('.inventory-dropdown > select').addClass("input-text inventory");
             $.each(response, function (i, item) {
                 $('.inventory-dropdown > select').append($('<option>', {
                     value: item.value,
                     text : item.text
                 }));
             });
             $(".btn-save").html("Simpan");
             $(".btn-save").data("number", roomNumber);
             $(".btn-save").addClass("insert-new-room-item");
        },
    });
});
$(document).on("click",".insert-new-room-item",function (event) {
    let dto = {
        roomNumber: $(this).data("number"),
        inventoryName: $('.inventory').val(),
        quantity: $('#qty').val()
    };
    $.ajax({
        method: "POST",
        url: BASE_URL+"/api/room-inventory",
        data: JSON.stringify(dto),
        contentType: "application/json",
        success: function (response) {
          location.reload();
        },
    });
});
$(".btn-delete-item").click(function (event) {
  const name = $(this).data("name");
  const id = $(this).data("id");
  $(".delete-item").data('id', id);
  $(".modal-body > h2").html("Apakah anda yakin ingin menghapus "+name+"?");
  $(".modal-delete-item").show();
});
$(".delete-item").click(function (event) {
    const id = $(this).data("id");
    $.ajax({
      method: "DELETE",
      url: BASE_URL+"/api/room-inventory/"+id,
      contentType: "application/json",
      success: function (response) {
        sessionStorage.setItem("success", response);
        location.reload();
      },
    });
});
//room item
//room service
$(".add-new-service").click(function(event){
    $(".employee-number").attr('readonly', false);
    $(".modal-body > h2").html("Insert New Room Service");
    $(".btn-save").html("Simpan");
    $(".employee-number").val("");
    $(".first-name").val("");
    $(".middle-name").val("");
    $(".last-name").val("");
    $(".outsourcing-company").val("");
    $(".modal-upsert-service").show();
});
$(".add-edit-service").click(function(event){
    const employeeNumber = $(this).data("id");
    $(".employee-number").attr('readonly', true);
    $(".modal-body > h2").html("Edit Room Service");
    $(".btn-save").html("Ubah");
    $.ajax({
       method: "GET",
       url: BASE_URL+"/api/room-service/"+employeeNumber,
       contentType: "application/json",
       success: function (response) {
           $(".employee-number").val(response.employeeNumber);
           $(".first-name").val(response.firstName);
           $(".middle-name").val(response.middleName);
           $(".last-name").val(response.lastName);
           $(".outsourcing-company").val(response.outsourcingCompany);
           $(".modal-upsert-service").show();
       },
    });
});
$(".btn-save").click(function (event) {
    let dto = {
        employeeNumber: $(".employee-number").val(),
        firstName: $(".first-name").val(),
        middleName: $(".middle-name").val(),
        lastName: $(".last-name").val(),
        outsourcingCompany: $(".outsourcing-company").val(),
    }
    $.ajax({
        method: "PUT",
        url: BASE_URL+"/api/room-service",
        data: JSON.stringify(dto),
        contentType: "application/json",
        success: function (response) {
            location.reload();
        },
    });
});
//room service