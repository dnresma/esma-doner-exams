(function ($) {
    'use strict'

    function loadConsultants() {
        const consultantsContainer = $("#consultants-container");
        $.ajax({
            url: "data/consultants.json",
            method: "GET",
            dataType: "json"
        }).done(function (data) {
            console.log(data)
            consultantsContainer.empty();
            data.forEach(function (consultant) {
                const badgeClass = 
                consultant.status === 'Müsait' ? 'text-bg-success'
                    : consultant.status === 'Görevde' ? 'text-bg-warning'
                    : 'text-bg-danger';
                const disabledAttr = consultant.status !== 'Müsait' ? 'disabled'
                    : ' ';
                const cardHTML = `
                <div class="col-12 col-md-4 col-lg-3">
                    <div class="card cons-card">
                        <img src="${consultant.image}" class="card-img-top" alt="${consultant.name}">
                        <div class="card-body">
                            <h5 class="card-title fw-bolder">${consultant.name}</h5>
                            <p class="card-text">${consultant.specialty}</p>
                            <p class="card-text fw-medium text-muted ">Tecrübe: ${consultant.experience}</p>
                            <span class="badge ${badgeClass}">${consultant.status}</span>
                    </div>
                </div>
                `;
                consultantsContainer.append(cardHTML);
            })
        }).fail(function (error) {
            console.error('HATA: ', error);
            consultantsContainer.html(`
                <div class="col-12">
                    <div class='alert alert-danger'>
                        Veri çekilemedi. Bağlantınızı kontrol edin.
                    </div>
                </div>
                `);
        })
        
    }

    $(function () {
        loadConsultants();
    })
}) (jQuery);