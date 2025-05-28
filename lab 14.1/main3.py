import pandas as pd
import matplotlib.pyplot as plt

df = pd.read_csv('titanic.csv')

print(df.info())

print(df.head(5))

print(df.tail(10))

not_survived_df = df[df['Survived'] == 0]
print("Люди, які не вижили:")
print(not_survived_df.head())

print("Розподіл класів пасажирів, які не вижили:")
print(not_survived_df['Pclass'].value_counts())

def age_category(age):
    if pd.isna(age):
        return 'Unknown'
    elif age < 13:
        return 'Child'
    elif age < 18:
        return 'Teen'
    elif age < 30:
        return 'Young Adult'
    elif age < 60:
        return 'Adult'
    else:
        return 'Senior'

print("Вікова категорія пасжирів")
not_survived_df = not_survived_df.copy()
not_survived_df['Age Category'] = not_survived_df['Age'].apply(age_category)

age_pclass_counts = not_survived_df.groupby(['Pclass', 'Age Category']).size().unstack(fill_value=0)

age_pclass_counts.plot(kind='bar', stacked=False)
plt.title('Кількість не виживших за віковими категоріями та класами')
plt.xlabel('Клас')
plt.ylabel('Кількість не виживших')
plt.legend(title='Вікова категорія')
plt.xticks(rotation=0)
plt.tight_layout()
plt.show()