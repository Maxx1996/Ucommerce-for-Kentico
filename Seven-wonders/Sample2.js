handle(handlerInput) {
         const data = require('./data/intro.json');
        const template = require('./templates/intro.json');
        const speakOutput = 'we have seven wonders in the world. It was a campaign started in 2000 to choose Wonders of the World from a selection of 200 existing monuments. The popularity poll was led by Canadian-Swiss Bernard Weber and organized by the New7Wonders Foundation based in Zurich, Switzerland, with winners announced on 7 July 2007 in Lisbon.';
       if (supportsAPL(handlerInput)) {
             handlerInput.responseBuilder
             .addDirective({
                type: 'Alexa.Presentation.APL.RenderDocument',
                version: '1.0',
                document: template,
                datasources: data
            })
        }
        return handlerInput.responseBuilder
            .speak(speakOutput)
            .withSimpleCard('Wonders Of the World', speakOutput)
            .getResponse();
    }
};