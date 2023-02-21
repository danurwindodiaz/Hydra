const modal = document.querySelector(".modal");
const BASE_URL = "http://localhost:5299/";

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

$(".dropdown-skill").change(function (event) {
    const skillId = $(this).val();
    $.ajax({
        method: "GET",
        url: BASE_URL+"itc/GetDropdownTrainer/"+skillId,
        contentType: "application/json",
        success: function (response) {
            $(".dropdown-trainer").empty();
            if (response.length == 0) {
                $(".dropdown-trainer").
                    append($('<option>', {
                        value: null,
                        text: 'Trainer tidak ditemukan'
                    }));
            } else {
                for (var i = 0; i < response.length; i++) {
                    $(".dropdown-trainer").append($('<option>', {
                        value: response[i].value,
                        text: response[i].text
                    }));
                }
            }            
        },
    });
});

$(".btn-selesai").click(function (event) {
    const id = $(this).data("id");
    const itc = $(this).data("itc");
    const materi = $(this).data("materi");
    $("#id-course").val(id);
    $(".modal-body > h3").html("Selesaikan " + itc + "?");
    $(".modal-body > p").html("Apakah tanggal selesai " + itc + " dengan materi " + materi + " benar ?" +
        "jika tidak mohon untuk ubah tanggalnya.");
    $(".modal-selesai").show();
});

$(".btn-selesaikan-course").click(function (event) {
    let dto = {
        Id: $("#id-course").val(),
        EndDate: $("#tanggal-selesai").val(),
    }

    $.ajax({
        method: "PATCH",
        url: BASE_URL + "course/selesaikan-course",
        data: JSON.stringify(dto),
        contentType: "application/json",
        success: function (response) {
            location.reload();
        },
        error: function (response) {
            console.log(response);
        }
    });
});
