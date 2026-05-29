window.changeTheme = (theme) => {

    const root = document.documentElement;

    switch (theme) {

        // 庭の新鮮さ
        case "garden":

            root.style.setProperty("--color-text", "#EE693F");
            root.style.setProperty("--color-background", "#CAEBCD");
            root.style.setProperty("--color-primary", "#F69454");
            root.style.setProperty("--color-secondary", "#739F3D");
            root.style.setProperty("--color-card", "#FCFDFE");

            break;

        // ブルーベリー
        case "blueberry":

            root.style.setProperty("--color-text", "#1E1F26");
            root.style.setProperty("--color-background", "#D0E1F9");
            root.style.setProperty("--color-primary", "#283655");
            root.style.setProperty("--color-secondary", "#4D648D");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 温かみと素朴さ
        case "warmthAndSimplicity":

            root.style.setProperty("--color-text", "#805A3B");
            root.style.setProperty("--color-background", "#FEF2E4");
            root.style.setProperty("--color-primary", "#C60000");
            root.style.setProperty("--color-secondary", "#4D648D");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // フレッシュグリーン
        case "freshGreen":

            root.style.setProperty("--color-text", "#265C00");
            root.style.setProperty("--color-background", "#FDFFFF");
            root.style.setProperty("--color-primary", "#68A225");
            root.style.setProperty("--color-secondary", "#B3DE81");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // スパイスのような中間色
        case "spices":

            root.style.setProperty("--color-text", "#662E1C");
            root.style.setProperty("--color-background", "#EBDCB2");
            root.style.setProperty("--color-primary", "#AF4425");
            root.style.setProperty("--color-secondary", "#EBDCB2");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;


        // 陽気な柑橘系
        case "citrus":

            root.style.setProperty("--color-text", "#FA4032");
            root.style.setProperty("--color-background", "#FEF3E2");
            root.style.setProperty("--color-primary", "#FA812F");
            root.style.setProperty("--color-secondary", "#FAAF08");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;


        // ルビー
        case "ruby":

            root.style.setProperty("--color-text", "#D8412F");
            root.style.setProperty("--color-background", "#FCFDFE");
            root.style.setProperty("--color-primary", "#FE7A47");
            root.style.setProperty("--color-secondary", "#F5CA99");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;


        // 霞んだ緑
        case "hazyGreen":

            root.style.setProperty("--color-text", "#04202C");
            root.style.setProperty("--color-background", "#C9D1CB");
            root.style.setProperty("--color-primary", "#304040");
            root.style.setProperty("--color-secondary", "#5B7065");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // アクアブルー
        case "aquaBlue":

            root.style.setProperty("--color-text", "#004D47");
            root.style.setProperty("--color-background", "#B9C4C9");
            root.style.setProperty("--color-primary", "#128277");
            root.style.setProperty("--color-secondary", "#52958b");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 都会のオアシス
        case "arbanOasis":

            root.style.setProperty("--color-text", "#2A2922");
            root.style.setProperty("--color-background", "#F3EBDD");
            root.style.setProperty("--color-primary", "#7D5642");
            root.style.setProperty("--color-secondary", "#506D2F");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // コスモポリタン
        case "cosmopolitan":

            root.style.setProperty("--color-text", "#5A4E4D");
            root.style.setProperty("--color-background", "#DDA288");
            root.style.setProperty("--color-primary", "#7E675E");
            root.style.setProperty("--color-secondary", "#8593AE");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // フレンドリー
        case "frienly":

            root.style.setProperty("--color-text", "#FA8D62");
            root.style.setProperty("--color-background", "#B2DBD5");
            root.style.setProperty("--color-primary", "#2B616D");
            root.style.setProperty("--color-secondary", "#B2DBD5");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 海の輝き
        case "shineOfSea":

            root.style.setProperty("--color-text", "#FF4447");
            root.style.setProperty("--color-background", "#A2E1DF");
            root.style.setProperty("--color-primary", "#257985");
            root.style.setProperty("--color-secondary", "#5EA8A7");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 北極の夜明け
        case "arcticDawn":

            root.style.setProperty("--color-text", "#006C84");
            root.style.setProperty("--color-background", "#E2E8E4");
            root.style.setProperty("--color-primary", "#6EB5C0");
            root.style.setProperty("--color-secondary", "#FFCCBB");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 霞んだグレー
        case "hazyGray":

            root.style.setProperty("--color-text", "#2C4A52");
            root.style.setProperty("--color-background", "#F4EBDB");
            root.style.setProperty("--color-primary", "#537072");
            root.style.setProperty("--color-secondary", "#8E9B97");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 草原
        case "glassland":

            root.style.setProperty("--color-text", "#524A3A");
            root.style.setProperty("--color-background", "#FFFAE1");
            root.style.setProperty("--color-primary", "#5A5F37");
            root.style.setProperty("--color-secondary", "#919636");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // スマートモダン
        case "smartModern":

            root.style.setProperty("--color-text", "#2F2E33");
            root.style.setProperty("--color-background", "#C6F6FF");
            root.style.setProperty("--color-primary", "#3A5199");
            root.style.setProperty("--color-secondary", "#D5D6D2");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 秋のオレンジ
        case "autumnOrange":

            root.style.setProperty("--color-text", "#896E69");
            root.style.setProperty("--color-background", "#F9F9FF");
            root.style.setProperty("--color-primary", "#D55448");
            root.style.setProperty("--color-secondary", "#FFA577");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // いぶし銀
        case "smokedSilver":

            root.style.setProperty("--color-text", "#080706");
            root.style.setProperty("--color-background", "#EFEFEF");
            root.style.setProperty("--color-primary", "#594D46");
            root.style.setProperty("--color-secondary", "#D1B280");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 薄い中間色
        case "thinMiddle":

            root.style.setProperty("--color-text", "#A57C65");
            root.style.setProperty("--color-background", "#FAEFD4");
            root.style.setProperty("--color-primary", "#688B8A");
            root.style.setProperty("--color-secondary", "#A0B084");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 暗いハンサム
        case "darkHandsome":

            root.style.setProperty("--color-text", "#42313A");
            root.style.setProperty("--color-background", "#F1DCC9");
            root.style.setProperty("--color-primary", "#6C2D2C");
            root.style.setProperty("--color-secondary", "#9F4636");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // アーバンリビング
        case "urbanLiving":

            root.style.setProperty("--color-text", "#232122");
            root.style.setProperty("--color-background", "#DDDEDE");
            root.style.setProperty("--color-primary", "#7BA4A8");
            root.style.setProperty("--color-secondary", "#A5C05B");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // くすんだ紫
        case "dullPurple":

            root.style.setProperty("--color-text", "#727077");
            root.style.setProperty("--color-background", "#EED8C9");
            root.style.setProperty("--color-primary", "#E99787");
            root.style.setProperty("--color-secondary", "#A49592");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 氷のような青とグレー
        case "iceBlue":

            root.style.setProperty("--color-text", "#1995AD");
            root.style.setProperty("--color-background", "#F1F1F2");
            root.style.setProperty("--color-primary", "#A1D6E2");
            root.style.setProperty("--color-secondary", "#BCBABE");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // 可憐
        case "Pretty":

            root.style.setProperty("--color-text", "#F18D9E");
            root.style.setProperty("--color-background", "#98DBC6");
            root.style.setProperty("--color-primary", "#5BC8AC");
            root.style.setProperty("--color-secondary", "#E6D72A");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

        // クールブルー
        case "coolBlue":

            root.style.setProperty("--color-text", "#003B46");
            root.style.setProperty("--color-background", "#C4DFE6");
            root.style.setProperty("--color-primary", "#07575B");
            root.style.setProperty("--color-secondary", "#66A5AD");
            root.style.setProperty("--color-card", "#FFFFFF");

            break;

    }
}