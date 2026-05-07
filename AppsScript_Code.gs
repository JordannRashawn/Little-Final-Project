function doPost(e) {
  var sheet = SpreadsheetApp.getActiveSpreadsheet().getActiveSheet();
  var data = JSON.parse(e.postData.contents);

  sheet.appendRow([
    data.name,
    data.birthdate,
    data.zodiac
  ]);

  return ContentService
    .createTextOutput("Success")
    .setMimeType(ContentService.MimeType.TEXT);
}

function doGet() {
  var sheet = SpreadsheetApp.getActiveSpreadsheet().getActiveSheet();
  var data = sheet.getDataRange().getValues();
  var result = [];

  for (var i = 1; i < data.length; i++) {
    result.push({
      name: data[i][0],
      birthdate: data[i][1],
      zodiac: data[i][2]
    });
  }

  return ContentService
    .createTextOutput(JSON.stringify(result))
    .setMimeType(ContentService.MimeType.JSON);
}
